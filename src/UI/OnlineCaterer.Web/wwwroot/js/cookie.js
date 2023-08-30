export default function useCookie() {
    return {
        get(cookieName) {
            const decoded = decodeURIComponent(document.cookie);
            const cookieArray = decoded.split(";");
            const cookieResult = cookieArray.find((cookie) => {
                return cookie.startsWith(cookieName)
                    || cookie.startsWith(` ${cookieName}`);
            });
            if (cookieResult !== undefined) {
                const keyValuePair = cookieResult.split('=');
                return keyValuePair[1];
            }
            return null;
        },
        set(name, value, time) {
            document.cookie = `${name}=${value}; expires=${time}; path=/`;
        }
    }
}

const hoursInDay = 24;
const minuteInHour = 60;
const secondsInMinute = 60;
const secondsToMiliseconds = 1000;

export const Time = {
    day(number) {
        const date = new Date();
        date.setTime(date.getTime()
            + number * hoursInDay * minuteInHour
            * secondsInMinute * secondsToMiliseconds);
        return date.toUTCString();
    }
}
