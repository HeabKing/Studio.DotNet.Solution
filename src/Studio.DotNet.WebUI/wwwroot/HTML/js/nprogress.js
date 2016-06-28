//-------------------------------- 获取百分比 -----------------------------------
// img 标签数组
var imgTags = document.getElementsByTagName("img");
// 刷新当前图片下载完成的百分比
function flashPercentage() {
	// 当前下载完成的图片的数量
	var imgCompleteCount = 0;
	// 如果没有图片, 直接退出
	if (imgTags.length <= 0) {
		window.ImgCompletePercetage = 1;
		return;
	}
	// 不管图片下载成功还是失败, 只要不是正在下载, 那么就算他完成了
	for (var index = 0; index < imgTags.length; index++) {
		if (imgTags[index].complete === true) {
			imgCompleteCount++;
		}
	}
	window.ImgCompletePercetage = imgCompleteCount / imgTags.length;
}
$(function () {
	self.setInterval("flashPercentage();", 200);
});
//---------------------------------- NProgress.css ----------------------------------
$(function () {
	$("head").children().last().after("<style>/* Make clicks pass-through */#nprogress {pointer-events: none;}#nprogress .bar {background: #29d;position: fixed;z-index: 100;top: 0;left: 0;width: 100%;height: 2px;}/* Fancy blur effect */#nprogress .peg {display: block;position: absolute;right: 0px;width: 100px;height: 100%;box-shadow: 0 0 10px #29d, 0 0 5px #29d;opacity: 1.0;-webkit-transform: rotate(3deg) translate(0px, -4px);-ms-transform: rotate(3deg) translate(0px, -4px);transform: rotate(3deg) translate(0px, -4px);}/* Remove these to get rid of the spinner */#nprogress .spinner {display: block;position: fixed;z-index: 100;top: 15px;right: 15px;}#nprogress .spinner-icon {width: 18px;height: 18px;box-sizing: border-box;border: solid 2px transparent;border-top-color: #29d;border-left-color: #29d;border-radius: 50%;-webkit-animation: nprogress-spinner 400ms linear infinite;animation: nprogress-spinner 400ms linear infinite;}@-webkit-keyframes nprogress-spinner {0% {-webkit-transform: rotate(0deg);}100% {-webkit-transform: rotate(360deg);}}@keyframes nprogress-spinner {0% {transform: rotate(0deg);}100% {transform: rotate(360deg);}}</style>");
});
//---------------------------------- NProgress.js -----------------------------------
/*! NProgress (c) 2013, Rico Sta. Cruz
 *  http://ricostacruz.com/nprogress */

; (function (factory) {

	if (typeof module === 'function') {
		module.exports = factory(this.jQuery || require('jquery'));
	} else if (typeof define === 'function' && define.amd) {
		define(['jquery'], function ($) {
			return factory($);
		});
	} else {
		this.NProgress = factory(this.jQuery);
	}

})(function ($) {
	var NProgress = {};

	NProgress.version = '0.1.2';

	var Settings = NProgress.settings = {
		minimum: 0.08,
		easing: 'ease',
		positionUsing: '',
		speed: 200,
		trickle: true,
		trickleRate: 0.02,
		trickleSpeed: 800,
		showSpinner: true,
		template: '<div class="bar" role="bar"><div class="peg"></div></div><div class="spinner" role="spinner"><div class="spinner-icon"></div></div>'
	};

	/**
	 * Updates configuration.
	 *
	 *     NProgress.configure({
	 *       minimum: 0.1
	 *     });
	 */
	NProgress.configure = function (options) {
		$.extend(Settings, options);
		return this;
	};

	/**
	 * Last number.
	 */

	NProgress.status = null;

	/**
	 * Sets the progress bar status, where `n` is a number from `0.0` to `1.0`.
	 *
	 *     NProgress.set(0.4);
	 *     NProgress.set(1.0);
	 */

	NProgress.set = function (n) {
		var started = NProgress.isStarted();

		n = clamp(n, Settings.minimum, 1);
		NProgress.status = (n === 1 ? null : n);

		var $progress = NProgress.render(!started),
			$bar = $progress.find('[role="bar"]'),
			speed = Settings.speed,
			ease = Settings.easing;

		$progress[0].offsetWidth; /* Repaint */

		$progress.queue(function (next) {
			// Set positionUsing if it hasn't already been set
			if (Settings.positionUsing === '') Settings.positionUsing = NProgress.getPositioningCSS();

			// Add transition
			$bar.css(barPositionCSS(n, speed, ease));

			if (n === 1) {
				// Fade out
				$progress.css({ transition: 'none', opacity: 1 });
				$progress[0].offsetWidth; /* Repaint */

				setTimeout(function () {
					$progress.css({ transition: 'all ' + speed + 'ms linear', opacity: 0 });
					setTimeout(function () {
						NProgress.remove();
						next();
					}, speed);
				}, speed);
			} else {
				setTimeout(next, speed);
			}
		});

		return this;
	};

	NProgress.isStarted = function () {
		return typeof NProgress.status === 'number';
	};

	/**
	 * Shows the progress bar.
	 * This is the same as setting the status to 0%, except that it doesn't go backwards.
	 *
	 *     NProgress.start();
	 *
	 */
	NProgress.start = function () {
		if (!NProgress.status) NProgress.set(0);

		var work = function () {
			setTimeout(function () {
				if (!NProgress.status) return;
				NProgress.trickle();
				work();
			}, Settings.trickleSpeed);
		};

		if (Settings.trickle) work();

		return this;
	};

	/**
	 * Hides the progress bar.
	 * This is the *sort of* the same as setting the status to 100%, with the
	 * difference being `done()` makes some placebo effect of some realistic motion.
	 *
	 *     NProgress.done();
	 *
	 * If `true` is passed, it will show the progress bar even if its hidden.
	 *
	 *     NProgress.done(true);
	 */

	NProgress.done = function (force) {
		if (!force && !NProgress.status) return this;

		return NProgress.inc(0.3 + 0.5 * Math.random()).set(1);
	};

	/**
	 * Increments by a random amount.
	 */

	NProgress.inc = function (amount) {
		var n = NProgress.status;

		if (!n) {
			return NProgress.start();
		} else {
			if (typeof amount !== 'number') {
				amount = (1 - n) * clamp(Math.random() * n, 0.1, 0.95);
			}

			n = clamp(n + amount, 0, 0.994);
			return NProgress.set(n);
		}
	};

	NProgress.trickle = function () {
		return NProgress.inc(Math.random() * Settings.trickleRate);
	};

	/**
	 * (Internal) renders the progress bar markup based on the `template`
	 * setting.
	 */

	NProgress.render = function (fromStart) {
		if (NProgress.isRendered()) return $("#nprogress");
		$('html').addClass('nprogress-busy');

		var $el = $("<div id='nprogress'>")
		  .html(Settings.template);

		var perc = fromStart ? '-100' : toBarPerc(NProgress.status || 0);

		$el.find('[role="bar"]').css({
			transition: 'all 0 linear',
			transform: 'translate3d(' + perc + '%,0,0)'
		});

		if (!Settings.showSpinner)
			$el.find('[role="spinner"]').remove();

		$el.appendTo(document.body);

		return $el;
	};

	/**
	 * Removes the element. Opposite of render().
	 */

	NProgress.remove = function () {
		$('html').removeClass('nprogress-busy');
		$('#nprogress').remove();
	};

	/**
	 * Checks if the progress bar is rendered.
	 */

	NProgress.isRendered = function () {
		return ($("#nprogress").length > 0);
	};

	/**
	 * Determine which positioning CSS rule to use.
	 */

	NProgress.getPositioningCSS = function () {
		// Sniff on document.body.style
		var bodyStyle = document.body.style;

		// Sniff prefixes
		var vendorPrefix = ('WebkitTransform' in bodyStyle) ? 'Webkit' :
						   ('MozTransform' in bodyStyle) ? 'Moz' :
						   ('msTransform' in bodyStyle) ? 'ms' :
						   ('OTransform' in bodyStyle) ? 'O' : '';

		if (vendorPrefix + 'Perspective' in bodyStyle) {
			// Modern browsers with 3D support, e.g. Webkit, IE10
			return 'translate3d';
		} else if (vendorPrefix + 'Transform' in bodyStyle) {
			// Browsers without 3D support, e.g. IE9
			return 'translate';
		} else {
			// Browsers without translate() support, e.g. IE7-8
			return 'margin';
		}
	};

	/**
	 * Helpers
	 */

	function clamp(n, min, max) {
		if (n < min) return min;
		if (n > max) return max;
		return n;
	}

	/**
	 * (Internal) converts a percentage (`0..1`) to a bar translateX
	 * percentage (`-100%..0%`).
	 */

	function toBarPerc(n) {
		return (-1 + n) * 100;
	}


	/**
	 * (Internal) returns the correct CSS for changing the bar's
	 * position given an n percentage, and speed and ease from Settings
	 */

	function barPositionCSS(n, speed, ease) {
		var barCSS;

		if (Settings.positionUsing === 'translate3d') {
			barCSS = { transform: 'translate3d(' + toBarPerc(n) + '%,0,0)' };
		} else if (Settings.positionUsing === 'translate') {
			barCSS = { transform: 'translate(' + toBarPerc(n) + '%,0)' };
		} else {
			barCSS = { 'margin-left': toBarPerc(n) + '%' };
		}

		barCSS.transition = 'all ' + speed + 'ms ' + ease;

		return barCSS;
	}

	return NProgress;
});


//---------------------------------- HTML ----------------------------------------
NProgress.start();
function flash() {
	// 如果一直没有下载完图片(>=), 那么使用NProgress的自动增加一点的效果
	// 如果已经加载完了(null), 就不要在重复一条一条的加载了
	if (NProgress.status == null || NProgress.status >= window.ImgCompletePercetage) {
		return;
	}
	NProgress.set(window.ImgCompletePercetage);
}
$(function () {
	self.setInterval("flash();", 200);
});
