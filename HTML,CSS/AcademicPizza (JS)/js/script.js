function getReceipt() {
	itemName = "";
	itemPrice = "";
	var countTotal = 0;
	var sizeTotal = 0;
	var sizeArray = document.getElementsByClassName("size");
	for (var i = 0; i < sizeArray.length; i++) {
		if (sizeArray[i].checked) {
			var sizeSelected = sizeArray[i].value;
		}
	}
	if (sizeSelected === "Personal") {
		sizeTotal = 6;
		itemPrice = itemPrice + sizeTotal + "<br>";
	} else if (sizeSelected === "Medium") {
		sizeTotal = 10;
		itemPrice = itemPrice + sizeTotal + "<br>";
	} else if (sizeSelected === "Large") {
		sizeTotal = 14;
		itemPrice = itemPrice + sizeTotal + "<br>";
	} else if (sizeSelected === "Extra Large") {
		sizeTotal = 16;
		itemPrice = itemPrice + sizeTotal + "<br>";
	}
	itemName = itemName + sizeSelected + "<br>";
	countTotal = sizeTotal;
	getMeats(countTotal,itemName,itemPrice);
};

function getMeats(countTotal,itemName,itemPrice) {
	var meatsTotal = 0;
	var meatsSelected = [];
	var meatsArray = document.getElementsByClassName("meats");
	for (var j = 0; j < meatsArray.length; j++) {
		if (meatsArray[j].checked) {
			meatsSelected.push(meatsArray[j].value);
		}
	}
	var meatsCount = meatsSelected.length;
	if (meatsCount > 1) {
		meatsTotal = (meatsCount - 1);
	} else {
		meatsTotal = 0;
	}
	for (var j = 0; j < meatsSelected.length; j++) {
		itemName = itemName + meatsSelected[j] + "<br>";
		if (meatsCount < 2) {
			itemPrice = itemPrice + 0 + "<br>";
			meatsCount = meatsCount -1;
		} else {
			itemPrice = itemPrice + 1 + "<br>";
			meatsCount = meatsCount -1;
		}
	}
	countTotal = (countTotal + meatsTotal);
	getVeggies(countTotal,itemName,itemPrice);
};

function getVeggies(countTotal,itemName,itemPrice) {
	var veggiesTotal = 0;
	var veggiesSelected = [];
	var veggiesArray = document.getElementsByClassName("veggies");
	for (var j = 0; j < veggiesArray.length; j++) {
		if (veggiesArray[j].checked) {
			veggiesSelected.push(veggiesArray[j].value);
		}
	}
	var veggiesCount = veggiesSelected.length;
	if (veggiesCount > 1) {
		veggiesTotal = (veggiesCount -1);
	} else {
		veggiesTotal = 0;
	}
	for (var j = 0; j < veggiesSelected.length; j++) {
		itemName = itemName + veggiesSelected[j] + "<br>";
		if (veggiesCount < 2) {
			itemPrice = itemPrice + 0 + "<br>";
			veggiesCount = (veggiesCount - 1);
		} else {
			itemPrice = itemPrice + 1 + "<br>";
			veggiesCount = (veggiesCount -1);
		}
	}
	countTotal = (countTotal + veggiesTotal);
	getCheese(countTotal,itemName,itemPrice);
};

function getCheese(countTotal,itemName,itemPrice) {
	var cheeseTotal = 0;
	var cheeseSelected = [];
	var cheeseArray = document.getElementsByClassName("cheese");
	for (var j = 0; j < cheeseArray.length; j++) {
		if (cheeseArray[j].checked) {
			cheeseSelected = cheeseArray[j].value;
		}
		if (cheeseSelected === "Extra Cheese") {
			cheeseTotal = 3; 
		}
	}
	itemName = itemName + cheeseSelected + "<br>";
	itemPrice = itemPrice + cheeseTotal + "<br>";
	countTotal = (countTotal + cheeseTotal);
	getCrust(countTotal,itemName,itemPrice);
};

function getCrust(countTotal,itemName,itemPrice) {
	var crustTotal = 0;
	var crustSelected;
	var crustArray = document.getElementsByClassName("crust");
	for (var j = 0; j < crustArray.length; j++) {
		if (crustArray[j].checked) {
			crustSelected = crustArray[j].value;
		}
		if (crustSelected === "Cheese Stuffed Crust") {
			crustTotal = 3;
		}
	}
	itemName = itemName + crustSelected + "<br>";
	itemPrice = itemPrice + crustTotal + "<br>";
	countTotal = (countTotal + crustTotal);
	getSauce(countTotal,itemName,itemPrice);
};

function getSauce(countTotal,itemName,itemPrice) {
	var sauceSelected = [];
	var sauceArray = document.getElementsByClassName("sauce");
	for (var j = 0; j < sauceArray.length; j++) {
		if (sauceArray[j].checked) {
			sauceSelected = sauceArray[j].value;
		}
	}
	itemName = itemName + sauceSelected + "<br>";
	itemPrice = itemPrice + 0 + "<br>";
	countTotal = countTotal;
	document.getElementById("receipt").style.opacity = 1;
	document.getElementById("name").innerHTML = itemName;
	document.getElementById("amount").innerHTML = itemPrice;
	document.getElementById("totalAmount").innerHTML = "<h2>$ " + countTotal + "</h2>";
};

function clearAll() {
	document.getElementById("formSelection").reset();
	document.getElementById("receipt").style.opacity = 0;
};