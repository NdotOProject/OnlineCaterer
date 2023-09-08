
const impactingCssProps = {
    left: 'left',
    offsetValue: '--offset-value',
    zIndex: 'z-index'
}
const animateDuration = 2000;
const carouselItems = $('.caterer_carousel-item');

function moveClass(name, fromObj, toObj) {
    fromObj.removeClass(name);
    toObj.addClass(name);
}

function carouselItemCreator(classNameOrDOM) {
    const selector = $(classNameOrDOM);
    return {
        selector,
        offsetValue: Number(selector.css(impactingCssProps.offsetValue)),
        tempZIndexValue: Number(selector.css(impactingCssProps.zIndex)),
        finalZIndexValue: Number(selector.css(impactingCssProps.zIndex)),
        offsetLeft: selector[0].offsetLeft,
    };
}

function moveCssWithAnimate(fromItem, toItem) {
    const selector = toItem.selector;
    selector.css({
        [impactingCssProps.zIndex]: fromItem.tempZIndexValue
    });
    selector.animate(
        {
            [impactingCssProps.left]: fromItem.offsetLeft
        },
        animateDuration,
        () => {
            selector.css(
                {
                    [impactingCssProps.offsetValue]: fromItem.offsetValue,
                    [impactingCssProps.zIndex]: fromItem.finalZIndexValue
                }
            );
        }
    );
}

function handleClick(clickedItem) {
    const currentItem = carouselItemCreator(clickedItem);
    const currentAcitveItem = carouselItemCreator('.caterer_carousel-item.active');
    const tempItem = currentItem;

    moveClass('active', currentAcitveItem.selector, currentItem.selector);

    moveCssWithAnimate(
        {
            ...currentAcitveItem,
            tempZIndexValue: currentAcitveItem.finalZIndexValue + 1
        },
        currentItem
    );

    setTimeout(() => {
        moveCssWithAnimate(tempItem, currentAcitveItem);
    }, animateDuration);
}

carouselItems.each((index, item) => {
    let itemSelector = $(item);
    itemSelector.css({
        [impactingCssProps.left]:
            `calc(var(${impactingCssProps.offsetValue})`
            + ` * ${itemSelector[0].clientWidth / 2}px)`
    });
    itemSelector.click(() => {
        if (!itemSelector.hasClass('active')) {
            handleClick(itemSelector);
        }
    });
});
