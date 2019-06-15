
var mymap;
var LeafIcon = L.Icon.extend({
    options: {
        shadowUrl: 'leaf-shadow.png',
        iconSize: [24, 40],
        shadowSize: [10, 20],
        iconAnchor: [12, 40],
        shadowAnchor: [6, 20],
        popupAnchor: [-3, -76]
    }
});

// https://github.com/pointhi/leaflet-color-markers

var greenIcon = new LeafIcon({ iconUrl: 'Content/Leaflet/marker-icon-green.png' }),
    yellowIcon = new LeafIcon({ iconUrl: 'Content/Leaflet/marker-icon-yellow.png' }),
    orangeIcon = new LeafIcon({ iconUrl: 'Content/Leaflet/marker-icon-orange.png' });
    redIcon = new LeafIcon({ iconUrl: 'Content/Leaflet/marker-icon-red.png' })

$(document).ready(function () {
    refreshMap()
});

$(".filter-option").change(function () {
    refreshMap();
});

function buildMap() {

    if (mymap != undefined || mymap != null) {
        mymap.off();
        mymap.remove();
    }

    mymap = L.map('mapid').setView([48.1481102, 17.1065592], 9);

    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiZ29zaG85MyIsImEiOiJjandzdDMyY3AwNDJhNDJwY2Q1c2RrNnJuIn0.IIlpxgoNcqWHP3GxkFy13A', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox.streets',
        accessToken: 'your.mapbox.access.token'
    }).addTo(mymap);
}

function drawArea(celLat, celLong, color, icon, text) {
    let marker = L.marker([celLat, celLong], { icon: icon }).addTo(mymap);
    marker.bindPopup("<b>" + text + "</b>");
    let circle = L.circle([celLat, celLong], { color: color, fillColor: color, fillOpacity: 0.5, radius: 300 }).addTo(mymap);
    circle.bindPopup(text);
}

function refreshMap() {

    let payload = {
        'includeMale': $("#includeMale")[0].checked,
        'includeFemale': $("#includeFemale")[0].checked,
        'includeUnknowGender': $("#includeUnknowGender")[0].checked,
        'include_18_to_25': $("#include_18_to_25")[0].checked,
        'include_26_to_35': $("#include_26_to_35")[0].checked,
        'include_36_to_45': $("#include_36_to_45")[0].checked,
        'include_46_to_65': $("#include_46_to_65")[0].checked,
        'include_66_to_100': $("#include_66_to_100")[0].checked,
        'startDate': $("#startDate")[0].value
    };

    $.ajax({
        type: "POST",
        url: "/Home/GetCDRcoordinates",
        data: { 'searchObj': payload },
        dataType: "json",
        success: function (response) {
            console.log(response)
            buildMap();

            $.each(response, function (key, value) {
                let count = value["Count"];
                let celLat = value["CellLat"];
                let celLong = value["CelLong"];

                if (count === 1) {
                    drawArea(celLat, celLong, 'green', greenIcon, "1 call");
                } else if (count === 2) {
                    drawArea(celLat, celLong, 'yellow', yellowIcon, "2 calls");                    
                } else if (count === 3) {
                    drawArea(celLat, celLong, 'orange', orangeIcon, "3 calls");                   
                } else {
                    drawArea(celLat, celLong, 'red', redIcon, "4+ calls");                    
                }
            })
        },
        failure: function (response) {
            alert(response);
        },
        error: function (response) {
            alert(response);
        }
    });
}


