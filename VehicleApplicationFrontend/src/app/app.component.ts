import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { VehicleService } from './services/vehicle.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'vehicle-application-frontend';
  columns = ['company', 'vin', 'regnumber', 'status', 'lastCommunication'];
  dataChanged: Subscription;
  dataSource;

  constructor(private vehicleService: VehicleService) {}

  ngOnInit(){
    this.dataSource = new MatTableDataSource();
    this.dataChanged = this.vehicleService.dataChanged.subscribe(
      value => this.dataSource = new MatTableDataSource(value)
    );
    this.vehicleService.getVehicles();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
