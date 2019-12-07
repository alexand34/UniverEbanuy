
window.onload = function () {
    google.charts.load('current', { 'packages': ['corechart'] });

    // Set a callback to run when the Google Visualization API is loaded.
    //google.charts.setOnLoadCallback(drawChart);
}

function analyzeText() {
    let value = document.getElementById('basic-input').value;

    let arr = value.split('');
    let occurenciesFor1 = [];
    let occurenciesFor2 = [];
    let occurenciesFor3 = [];

    for (let i = 0; i < arr.length; i++) {
        let a = occurenciesFor1.find(x => x.name == arr[i]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor1.push({ name: arr[i], count: 1 })
        }
    }

    for (let i = 0; i < arr.length - 1; i++) {
        let a = occurenciesFor2.find(x => x.name == arr[i] + arr[i + 1]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor2.push({ name: arr[i] + arr[i + 1], count: 1 })
        }
    }

    console.log(occurenciesFor2)

    for (let i = 0; i < arr.length - 2; i++) {
        let a = occurenciesFor3.find(x => x.name == arr[i] + arr[i + 1] + arr[i + 2]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor3.push({ name: arr[i] + arr[i + 1] + arr[i + 2], count: 1 })
        }
    }

    console.log(occurenciesFor3);

    if (occurenciesFor2.length >= 10 && occurenciesFor2.length <= 15) {
        drawChart(occurenciesFor2.sort((a, b) => {
            if (a.name < b.name)
                return -1;
            if (a.name > b.name)
                return 1;
            return 0;
        }), "chart3", "кількість повторень для 2-х символів");
    }

    if (occurenciesFor3.length >= 10 && occurenciesFor3.length <= 15) {
        drawChart(occurenciesFor3.sort((a, b) => {
            if (a.name < b.name)
                return -1;
            if (a.name > b.name)
                return 1;
            return 0;
        }), "chart4", "кількість повторень для 3-х символів");
    }

    drawChart(occurenciesFor1.sort((a, b) => {
        if (a.name < b.name)
            return -1;
        if (a.name > b.name)
            return 1;
        return 0;
    }), "chart1", "кількість повторень за алфавітом");

    drawChart(occurenciesFor1.sort((a, b) => {
        if (a.count < b.count)
            return -1;
        if (a.count > b.count)
            return 1;
        return 0;
    }), "chart2", "кількість повторень символу за кількістю повторень");

    let text = caesarShift(value, 10);
    document.getElementById('caesarShift').value = text;
    arr = text.split('');

    occurenciesFor1 = [];
    occurenciesFor2 = [];
    occurenciesFor3 = [];

    for (let i = 0; i < arr.length; i++) {
        let a = occurenciesFor1.find(x => x.name == arr[i]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor1.push({ name: arr[i], count: 1 })
        }
    }

    for (let i = 0; i < arr.length - 1; i++) {
        let a = occurenciesFor2.find(x => x.name == arr[i] + arr[i + 1]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor2.push({ name: arr[i] + arr[i + 1], count: 1 })
        }
    }

    for (let i = 0; i < arr.length - 2; i++) {
        let a = occurenciesFor3.find(x => x.name == arr[i] + arr[i + 1] + arr[i + 2]);
        if (a) {
            a.count += 1;
        }
        else {
            occurenciesFor3.push({ name: arr[i] + arr[i + 1] + arr[i + 2], count: 1 })
        }
    }

    if (occurenciesFor2.length >= 10 && occurenciesFor2.length <= 15) {
        drawChart(occurenciesFor2.sort((a, b) => {
            if (a.name < b.name)
                return -1;
            if (a.name > b.name)
                return 1;
            return 0;
        }), "chart7", "кількість повторень для 2-х символів");
    }

    if (occurenciesFor3.length >= 10 && occurenciesFor3.length <= 15) {
        drawChart(occurenciesFor3.sort((a, b) => {
            if (a.name < b.name)
                return -1;
            if (a.name > b.name)
                return 1;
            return 0;
        }), "chart8", "кількість повторень для 3-х символів");
    }

    drawChart(occurenciesFor1.sort((a, b) => {
        if (a.name < b.name)
            return -1;
        if (a.name > b.name)
            return 1;
        return 0;
    }), "chart5", "кількість повторень за алфавітом");

    drawChart(occurenciesFor1.sort((a, b) => {
        if (a.count < b.count)
            return -1;
        if (a.count > b.count)
            return 1;
        return 0;
    }), "chart6", "кількість повторень символу за кількістю повторень");


    let final = caesarShift(text, -10);
    document.getElementById('caesarUnshift').value = final;

    let t =  encrypt(final, 'oleksandrdemianenko');
    document.getElementById('substitutionShift').value = t;
    document.getElementById('substitutionUnshift').value = decrypt(t, 'oleksandrdemianenko');
}


function drawChart(items, chart, text) {
    let els = [["Елемент", "Кількість"]];
    for (let i = 0; i < items.length; i++) {
        els.push([items[i].name, items[i].count])
    }

    var data = google.visualization.arrayToDataTable(els);

    var view = new google.visualization.DataView(data);


    var options = {
        title: text,
        width: 1000,
        height: 500,
        bar: { groupWidth: "80%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.ColumnChart(document.getElementById(chart));
    chart.draw(view, options);
}

function caesarShift(str, amount) {

    // Wrap the amount
    if (amount < 0)
        return caesarShift(str, amount + 26);

    // Make an output variable
    var output = '';

    // Go through each character
    for (var i = 0; i < str.length; i++) {

        // Get the character we'll be appending
        var c = str[i];

        // If it's a letter...
        if (c.match(/[a-z]/i)) {

            // Get its code
            var code = str.charCodeAt(i);

            // Uppercase letters
            if ((code >= 65) && (code <= 90))
                c = String.fromCharCode(((code - 65 + amount) % 26) + 65);

            // Lowercase letters
            else if ((code >= 97) && (code <= 122))
                c = String.fromCharCode(((code - 97 + amount) % 26) + 97);

        }

        // Append
        output += c;

    }

    // All done!
    return output;

};

const ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ '-,.;";
const ALPHABET_LIST = ALPHABET.split('');
const ALPHABET_RANGE = ALPHABET.length;
const ASCII_DIFF = 65;
function getSubstitutionMapFromKey(key) {
    const userKey = [... new Set(cleanString(key).split(''))];
    const remaining = ALPHABET_LIST.filter((c) => userKey.indexOf(c) == -1);

    return userKey.concat(remaining).join('');
}

const cleanString = (string) => {
    return string.toUpperCase().replace(/[^A-Z]/g, '');
}


function encrypt(plaintext, key) {
    const keyMap = getSubstitutionMapFromKey(key);

    return plaintext
        .replace(/\ +/g, ' ')
        .split(' ')
        .map((s) => stringToNumArray(s))
        .map((na) => na.map((n) => keyMap[n]))
        .map((na) => na.join(''))
        .join(' ');
}


function decrypt(ciphertext, key) {
    const keyMap = getSubstitutionMapFromKey(key);

    return ciphertext
        .replace(/\ +/g, ' ')
        .split(' ')
        .map((s) => s.split(''))
        .map((s) => s.map((c) => keyMap.indexOf(c)))
        .map((na) => na.map((n) => ALPHABET[n]))
        .map((na) => na.join(''))
        .join(' ');
}

function stringToNumArray(string) {
    return cleanString(string).split('').map(charToNum);
}


function charToNum(char) {
    return char.toUpperCase().charCodeAt(0) - ASCII_DIFF;
}