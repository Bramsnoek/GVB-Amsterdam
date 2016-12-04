function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");

    var targetDiv = document.getElementById(ev.target.id);
    var sourceDiv = document.getElementById(data);

    if (sourceDiv.parentNode.className.indexOf("column") > -1 && ev.target.id.indexOf("Tram") > -1) {

        var sectorId = (sourceDiv.parentNode.id).replace(/^\D+/g, "");
        var tramNumber = data.replace(/^\D+/g, "");

        $.ajax({
            type: "POST",
            url: "/Home/RemoveTramFromSector",
            data: { sectorId: sectorId, tramNumber: tramNumber },
            success: function () {
                BlockSectors(sectorId);
            },
            failure: function () {
            }
        });

        sourceDiv.removeChild(sourceDiv.getElementsByClassName('TramID')[0]);

        sourceDiv.parentNode.style.backgroundColor = '#708090';

        var tramNumber = document.createElement('div');
        tramNumber.innerHTML = data;
        tramNumber.id = data;
        tramNumber.className = "list-group-item";
        tramNumber.style.textAlign = "center";
        tramNumber.draggable = true;
        tramNumber.ondragstart = 'drag(event)';
        tramNumber.ondrop = 'drop(event)';
        tramNumber.ondragover = 'allowDrop(event)';

        sourceDiv.parentNode.removeChild(sourceDiv);
        targetDiv.parentNode.appendChild(tramNumber);

    }
    //if (targetDiv.className == "list-group-item" && sourceDiv.id.indexOf("Tram") > -1 && targetDiv.id.indexOf("Tram") > -1) {
    //    return;
    //}

    if (sourceDiv.parentNode.className.indexOf("column") > -1) {
        //sector to sector

        var sectorId = (targetDiv.id).replace(/^\D+/g, "");
        var sourceSectorId = (sourceDiv.parentNode.id).replace(/^\D+/g, "");

        $.ajax({
            type: "GET",
            url: "/Home/IsSectorBlocked",
            data: { sectorID: sectorId },
            success: function (result) {
                if (result == 1) {
                    var tramNumber = data.replace(/^\D+/g, "");
                    var newSectorId = targetDiv.id.replace(/^\D+/g, "");

                    sourceDiv.parentNode.style.backgroundColor = 'slategrey';
                    sourceDiv.parentNode.removeChild(sourceDiv);

                    GetTramColor(data, targetDiv);

                    addTramDiv(targetDiv.id, data);
                    $.ajax({
                        type: "POST",
                        url: "/Home/ChangeSector",
                        data: { sectorId: sectorId, newSectorId: newSectorId, tramNumber: tramNumber },
                        success: function () {
                            BlockSectors(sectorId);
                            BlockSectors(sourceSectorId);
                        },
                        failure: function () {
                        }
                    });
                }
            },
            failure: function (data) {
                return data;
            }
        });
    }
    else if (data.indexOf("Tram") > -1 && ev.target.id.indexOf("S") > -1) {
        // Set the sector color
        // data = tram x

        //alert(checkBlocked(targetDiv.id));

        var sectorId = (targetDiv.id).replace(/^\D+/g, "");

        $.ajax({
            type: "GET",
            url: "/Home/IsSectorBlocked",
            data: { sectorID: sectorId },
            success: function (result) {
                if (result == 1) {
                    var tramNumber = data.replace(/^\D+/g, "");

                    GetTramColor(data, targetDiv);

                    sourceDiv.parentNode.removeChild(sourceDiv);
                    addTramDiv(targetDiv.id, data);

                    $.ajax({
                        type: "POST",
                        url: "/Home/ChangeSector",
                        data: { sectorId: sectorId, newSectorId: sectorId, tramNumber: tramNumber },
                        success: function () {
                            BlockSectors(sectorId);
                        },
                        failure: function () {
                        }
                    });
                }
            },
            failure: function (data) {
                return data;
            }
        });
    }
}

function insertSimulate() {
    $.ajax({
        type: "GET",
        url: "/Home/GetSimulate",
        dataType: "json",
        success: function (data) {
            var sectorDiv = document.getElementById("S " + data[0]);

            var tramNumber = document.createElement('div');
            tramNumber.className = 'Tram';
            tramNumber.id = data[1];
            GetTramColor(data[1], sectorDiv);
            tramNumber.draggable = true;
            tramNumber.ondragstart = 'drag(event)';
            tramNumber.ondrop = 'drop(event)';
            tramNumber.ondragover = 'allowDrop(event)';

            var tramNumberP = document.createElement('p');
            tramNumberP.className = "TramID";
            tramNumberP.innerHTML = "Tram: " + data[1];

            tramNumber.appendChild(tramNumberP);
            sectorDiv.appendChild(tramNumber);
        },
        failure: function (data) {
        }
    });
}

var interval;
function toggleSimulate(state) {
    if (state == 1) {
        var sectors = document.getElementsByClassName('column');

        for (var i = 0; i < sectors.length; i++) {
            if (sectors[i].id.indexOf('S') > -1) {
                sectors[i].style.backgroundColor = 'slategrey';
                while (sectors[i].firstChild) {
                    sectors[i].removeChild(sectors[i].firstChild);
                }
            }
        }

        $.ajax({
            type: "POST",
            url: "/Home/StartSimulate",
            success: function () {
            },
            failure: function () {
            }
        });

        interval = setInterval(insertSimulate, 1000);
    }
    else {
        clearInterval(interval);
        location.reload();
    }
}

function addTramDiv(sectorDiv, data) {
    var tramNumber = document.createElement('div');
    tramNumber.className = 'Tram';
    tramNumber.id = data;
    tramNumber.draggable = true;
    tramNumber.ondragstart = 'drag(event)';
    tramNumber.ondrop = 'drop(event)';
    tramNumber.ondragover = 'allowDrop(event)';
    tramNumber.ondblclick = 'OpenTramModal(this.id)'

    var tramNumberP = document.createElement('p');
    tramNumberP.className = "TramID";
    tramNumberP.innerHTML = data.replace('L', '');

    tramNumber.appendChild(tramNumberP);

    document.getElementById(sectorDiv).appendChild(tramNumber);
    LoadContextMenu();
}

function BlockSectors(sectorId) {
    $.ajax({
        type: "GET",
        url: "/Home/GetBLockedSectorIds",
        dataType: "json",
        data: { sectorId: sectorId },
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].indexOf("B") > -1) {
                    var sectorId = data[i].replace(/^\D+/g, "");
                    var sector = document.getElementById('S ' + sectorId);

                    if (sector.childNodes[1] == undefined) {
                        sector.style.backgroundColor = 'slategrey';
                    }

                }
                else {
                    var sector = document.getElementById('S ' + data[i]);


                    sector.style.backgroundColor = '#d9534f';
                }

            }
        },
        error: function () {
            alert("error");
        }
    });
}

function SearchTrams() {
    var textBox = document.getElementById('ListFilter');
    var searchTerm = textBox.value;
    var tramNumber = searchTerm.replace(/^\D+/g, "");

    var list = document.getElementById('tramlist');

    var elems = list.getElementsByClassName('list-group-item');

    for (i = 0; i < elems.length; i++) {
        if (elems[i].id.indexOf(tramNumber) > -1) {
            elems[i].style.color = '#333';
        }
        else {
            elems[i].style.color = '#bdbdbd';

        }
    }
}

function filterState(stateId) {
    var elems = document.getElementsByClassName('Tram');

    for (i = 0; i < elems.length; i++) {
        var tramNumber = elems[i].id.replace(/^\D+/g, '');

        if (stateId == -1) {
            GetTramColor("Tram: " + tramNumber, elems[i].parentNode);
            continue;
        }

        ApplyFilter(tramNumber, stateId);
    }
}

function ApplyFilter(tramNumber, stateId) {
    $.ajax({
        type: "GET",
        url: "/Home/GetTramState",
        data: { tramNumber: tramNumber },
        success: function (data) {
            var sectorDiv = (document.getElementById('Tram: ' + tramNumber)).parentNode;

            if (((stateId == 2 || stateId == 1) && data == 3)) {
                GetTramColor('Tram: ' + tramNumber, sectorDiv);
            }
            else if (stateId != data) {
                sectorDiv.style.backgroundColor = '#bdbdbd';
            }
            else {
                GetTramColor('Tram: ' + tramNumber, sectorDiv);
            }
        },
        failure: function (data) {
        }
    });
}

function searchTram() {
    var textBox = document.getElementById('tramSearch');
    var searchTerm = textBox.value;
    var tramNumber = searchTerm.replace(/^\D+/g, "");

    $.ajax({
        type: "GET",
        url: "/Home/TramExists",
        data: { tramNumber: tramNumber },
        success: function (data) {
            if (data == "1") {
                OpenTramModal(tramNumber);
            }
            else {
                alert("No Tram Found!");
            }
        },
        failure: function (data) {
        }
    });
}

function GetTramColor(tramId, div) {
    var tramNumber = tramId.replace(/^\D+/g, '');

    $.ajax({
        type: "GET",
        url: "/Home/GetStateColor",
        data: { tramNumber: tramNumber },
        success: function (data) {
            div.style.backgroundColor = data;
        },
        failure: function (data) {
        }
    });
}

function UpdateTrackBlock(trackNumber, state) {
    pageContainer = document.getElementsByClassName('column ' + trackNumber);
    track = pageContainer[0];

    alert(track.className);

    if (state == 1) {
        track.style.backgroundColor = 'slategrey';
    }
    else {
        track.style.backgroundColor = '#d9534f';
    }
}

function UpdateTramColor(tramId) {
    var tramDiv = document.getElementById('Tram: ' + tramId);
    GetTramColor(tramDiv.id, tramDiv.parentNode);
}

function OpenTramModal(tramId) {
    var tramNumber = tramId.replace(/^\D+/g, '');

    $('#Tram').modal('show');

    LoadTramModal(tramNumber);
}

function OpenTrackModal(trackId) {
    $('#Track').modal('show');

    LoadTrackModal(trackId);
}

function ToggleSectorBlock(sectorID) {
    var sectorId = sectorID.replace(/^\D+/g, '');

    var sector = document.getElementById(sectorID);

    $.ajax({
        type: "GET",
        url: "/Home/ToggleSectorBlocked",
        data: { sectorID: sectorId },
        success: function (data) {
            if (data == 0) {
                sector.style.backgroundColor = '#d9534f';
            }
            else {
                sector.style.backgroundColor = 'slategrey';
            }
        },
        failure: function (data) {
        }
    });
}