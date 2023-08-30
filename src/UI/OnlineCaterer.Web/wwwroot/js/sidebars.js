
var navButton = document.querySelector(".nav_button");
var navMiddleRoot = document.querySelector("#nav_middle-root");
var navMiddleContent = document.querySelector('#nav_middle-content');
var sidebarRight = document.getElementById('sidebar_right');
const rightbarRoot = document.getElementById('rightbar-root');

const windowWidth = window.innerWidth;
const tabletWidth = 768;

if (windowWidth <= 768) {
    navMiddleRoot.removeChild(navMiddleContent);
} else {
    navMiddleRoot.appendChild(navMiddleContent);
}

rightbarRoot.removeChild(sidebarRight)

navButton.addEventListener('click', () => {
    navButton.classList.toggle('active');
    if (navButton.className.includes('active')) {
        rightbarRoot.appendChild(sidebarRight);
        rightbarRoot.classList.add('show');
        setTimeout(() => {
            sidebarRight.classList.add('show');
        }, 5);
    } else {
        sidebarRight.classList.remove('show');
        setTimeout(() => {
            rightbarRoot.classList.remove('show');
            rightbarRoot.removeChild(sidebarRight);
        }, 500);
    }
});

function tabletSetting(callbackIfTrue) {
    if (windowWidth <= tabletWidth) {
        callbackIfTrue();
    }
}