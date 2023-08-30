import useCookie from "./cookie.js";
import { Time } from "./cookie.js";

const cookie = useCookie();

const foodBoxs = document.getElementsByName("test");

const arrStr = decodeURIComponent(cookie.get("selectedFoodIds"));

let selectedFoodIds = JSON.parse(arrStr) ?? [];

foodBoxs.forEach((foodBox) => {
    if (selectedFoodIds.includes(foodBox.value)) {
        foodBox.checked = true;
    }

    foodBox.addEventListener('change', ev => {
        ev.preventDefault();

        if (foodBox.checked) {
            selectedFoodIds.push(foodBox.value);
        } else {
            selectedFoodIds = selectedFoodIds.filter(e => e != foodBox.value);
        }
        console.log(selectedFoodIds);

        let cookieStr = encodeURIComponent(JSON.stringify(selectedFoodIds));

        cookie.set('selectedFoodIds', cookieStr, Time.day(7));
    });
})



