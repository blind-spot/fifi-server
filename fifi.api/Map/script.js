$(function() {
    var templates = {
        table: '<table><tbody>{body}</tbody></table>',
        row:'<tr><th>{key}</th><td>{value}</td></tr>',
        link:'<tr><th>{key}</th><td><a href="{href}" target="_blank">{title}</a></td></tr>',
        busMarker: '<div class="bus-route" style="border-bottom-color: {color};" title="{title}">{route}</div>',
        busMarkerTitle: '{destination}\nCurrent direction: {direction}'
    };

    var osm = L.tileLayer('http://{s}.tile2.opencyclemap.org/transport/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors,' +
            'tiles from <a href="http://www.opencyclemap.org/">OpenCycleMap</a>'
    });

    var map = L.map('map', {
        center: [47.608804, -122.335638],
        zoom: 13,
        layers: [osm]
    });

    //L.control.locate({
    //    locateOptions: {
    //        maxZoom: 18
    //    },
    //    follow: true
    //}).addTo(map);

    L.control.scale().addTo(map);

    var hash = new L.Hash(map);

    function debug(val) {
      console.log(val);
    }

    // zoom start event
    // remove markers (animated and non-animated)
    map.on('zoomstart', function(e) {
        //seattleTransit.removeMarkers();
    });

    // zoom end event
    // add markers
    map.on('zoomend', function(e) {
        //seattleTransit.addMarkers();
    });

    // add markers when window  is in focus
    $(window).on('focus', function() {
        //debug("focus");
        //seattleTransit.addMarkers();
    });

    // remove markers when windo iis out of focus
    $(window).on('blur', function(){
        //debug("blur");
    });

    function loadReportInteraction() {
        var reportssUri = '/api/report/interaction/';

        function ajaxHelper(uri, method, data) {
            return $.ajax({
                type: method,
                url: uri,
                dataType: 'json',
                contentType: 'application/json',
                data: data ? JSON.stringify(data) : null
            }).fail(function (jqXHR, textStatus, errorThrown) {
                //self.error(errorThrown);
                console.log("error");
            });
        }

        function addMarker(data) {
            $.each(data, function (key, obj) {
                // console.log(obj.Location.Lat);
                // console.log(obj.Location.Long);
                // L.marker([47.608804, -122.335638]).addTo(map);
                L.marker([obj.Location.Lat, obj.Location.Long]).addTo(map);
            }); 
        }

        function getAllReports() {
            ajaxHelper(reportssUri, 'GET').done(function (data) {
                //self.books(data);
                console.log(data);
                addMarker(data);
            });
        }

        getAllReports();


    }

    loadReportInteraction();
});

