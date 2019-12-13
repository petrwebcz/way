import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { StateService } from 'src/app/services/state.service';
import { RoomApiClientService } from 'src/app/services/room-api-client.service';

@Component({
    selector: 'app-room',
    templateUrl: './room.component.html',
    styleUrls: ['./room.component.css']
})

export class RoomComponent implements OnInit, AfterViewInit, OnDestroy {
    @ViewChild('mapContainer', { static: false }) gmap: ElementRef;
    map: google.maps.Map;
    lat = 40.73061;
    lng = -73.935242;

    coordinates = new google.maps.LatLng(this.lat, this.lng);

    mapOptions: google.maps.MapOptions = {
        center: this.coordinates,
        zoom: 8
    };

    marker = new google.maps.Marker({
        position: this.coordinates,
        map: this.map,
    });

    constructor(
        private stateService: StateService,
        private roomApiClient: RoomApiClientService
    ) { }

    ngOnInit() {
    }

    ngAfterViewInit(): void {
        this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);
        this.marker.setMap(this.map);
    }

    ngOnDestroy(): void {
        this.map.unbindAll();
    }
}
