var xValues = ["Food Donation", "Educational Fund", "Health Donation", "Building Shelter"];
var yValues = [60, 35, 15, 20];
var barColors = [
    "#ff2e3d",
    "#f9737d",
    "#f7959c",
    "#a60c17"
];

new Chart("myChart", {
    type: "doughnut",
    data: {
        labels: xValues,
        datasets: [{
            backgroundColor: barColors,
            data: yValues
        }]
    },
    options: {
        title: {
            display: false,
            text: "World Wide Wine Production 2018"
        }
    }
});
