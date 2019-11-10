
var map;
var initMap = function () {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 49.8066344, lng: 23.9925693 },
        zoom: 15,
        mapTypeId: 'terrain',
        styles: [
            { elementType: 'geometry', stylers: [{ color: '#242f3e' }] },
            { elementType: 'labels.text.stroke', stylers: [{ color: '#242f3e' }] },
            { elementType: 'labels.text.fill', stylers: [{ color: '#746855' }] },
            {
                featureType: 'administrative.locality',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'poi',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'poi.park',
                elementType: 'geometry',
                stylers: [{ color: '#263c3f' }]
            },
            {
                featureType: 'poi.park',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#6b9a76' }]
            },
            {
                featureType: 'road',
                elementType: 'geometry',
                stylers: [{ color: '#38414e' }]
            },
            {
                featureType: 'road',
                elementType: 'geometry.stroke',
                stylers: [{ color: '#212a37' }]
            },
            {
                featureType: 'road',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#9ca5b3' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'geometry',
                stylers: [{ color: '#746855' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'geometry.stroke',
                stylers: [{ color: '#1f2835' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#f3d19c' }]
            },
            {
                featureType: 'transit',
                elementType: 'geometry',
                stylers: [{ color: '#2f3948' }]
            },
            {
                featureType: 'transit.station',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'water',
                elementType: 'geometry',
                stylers: [{ color: '#17263c' }]
            },
            {
                featureType: 'water',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#515c6d' }]
            },
            {
                featureType: 'water',
                elementType: 'labels.text.stroke',
                stylers: [{ color: '#17263c' }]
            }
        ]
    });
    var flightPlanCoordinates = [
        { lat: 37.772, lng: -122.214 },
        { lat: 21.291, lng: -157.821 },
        { lat: -18.142, lng: 178.431 },
        { lat: -27.467, lng: 153.027 }
    ];
    var flightPath = new google.maps.Polyline({
        path: flightPlanCoordinates,
        geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });
    flightPath.setMap(map);
    marker = new google.maps.Marker({
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        position: { lat: 49.8066344, lng: 23.9925693 }
    });
    //marker.addListener('click', toggleBounce);
}

function startSpinner() {
    $('.spinner-container').toggle('show')
    var shaft = $(".shaft");
    var dick = $(".dick");
    Number.prototype.map = function (istart, istop, ostart, ostop) {
        return ostart + (ostop - ostart) * ((this - istart) / (istop - istart));
    };
    Plot = function (stage) {

        this.setDimensions = function (x, y) {
            this.elm.style.width = x + 'px';
            this.elm.style.height = y + 'px';
            this.width = x;
            this.height = y;
        };
        this.position = function (x, y) {
            var xoffset = arguments[2] ? 0 : this.width / 2;
            var yoffset = arguments[2] ? 0 : this.height / 2;
            this.elm.style.left = (x - xoffset) + 'px';
            this.elm.style.top = (y - yoffset) + 'px';
            this.x = x;
            this.y = y;
        };
        this.setBackground = function (col) {
            this.elm.style.background = col;
        };
        this.kill = function () {
            stage.removeChild(this.elm);
        };
        this.rotate = function (str) {
            this.elm.style.webkitTransform = this.elm.style.MozTransform =
                this.elm.style.OTransform = this.elm.style.transform =
                'rotate(' + str + ')';
        };
        this.content = function (content) {
            this.elm.innerHTML = content;
        };
        this.round = function (round) {
            this.elm.style.borderRadius = round ? '50%/50%' : '';
        };
        this.elm = document.createElement('div');
        this.elm.style.position = 'absolute';
        stage.appendChild(this.elm);
    };

    var stage = document.querySelector('.stage'),
        message = 'Поставте 100 балів.'.toUpperCase(),
        plots = message.length,
        increase = Math.PI * 2 / plots,
        angle = -Math.PI,
        turnangle = 0,
        x = 0,
        y = 0,
        plotcache = [];

    for (var i = 0; i < plots; i++) {
        var p = new Plot(stage);
        p.content(message.substr(i, 1));
        p.setDimensions(40, 40);
        plotcache.push(p);
    }
    function rotate() {
        for (var i = 0; i < plots; i++) {
            x = 100 * Math.cos(angle) + 200;
            y = 100 * Math.sin(angle) + 200;
            turnangle = Math.atan2(y - 200, x - 200) * 180 / Math.PI + 90 + 'deg';
            plotcache[i].rotate(turnangle);
            plotcache[i].position(x, y);
            angle += increase;
        }
        angle += 0.06;

        shaft.css("-moz-transform", "rotate(" + (Math.sin(angle) * 25) + "deg)").css("-webkit-transform", "rotate(" + (Math.sin(angle) * 25) + "deg)");;
        dick.css("-moz-transform", "scale(" + Math.abs(Math.sin(angle)).map(0, 1, 0.8, 1) + ")").css("-webkit-transform", "scale(" + Math.abs(Math.sin(angle)).map(0, 1, 0.8, 1) + ")");;
    }


    setInterval(rotate, 1000 / 20);
}