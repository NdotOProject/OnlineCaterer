import useCookie from "../cookie.js";
import { Time } from "../cookie.js";

const LIST_NAME = "selectedFoodIds";
const cookie = useCookie();
const foodBoxs = document.getElementsByName("add_to_cart");
const arrStr = decodeURIComponent(cookie.get(LIST_NAME));
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
            selectedFoodIds = selectedFoodIds
                .filter(e => e != foodBox.value);
        }
        cookie.set(
            LIST_NAME,
            encodeURIComponent(
                JSON.stringify(selectedFoodIds)
            ),
            Time.day(7)
        );
    });
})

export function toggleSvg(inputId, labelId, svg) {
    const addToCartInput = document.getElementById(inputId);
    const addToCartLabel = document.getElementById(labelId);
    if (addToCartInput.checked) {
        addToCartLabel.removeChild(
            addToCartLabel.children.item(0)
        );
    }
    addToCartLabel.addEventListener('click', () => {
        if (addToCartInput.checked) {
            addToCartLabel.appendChild(
                document.createRange()
                    .createContextualFragment(svg)
            );
        } else {
            addToCartLabel.removeChild(
                addToCartLabel.children.item(0)
            );
        }
    });
}
