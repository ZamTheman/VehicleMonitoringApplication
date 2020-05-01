import { Injectable } from '@angular/core';
import { IVehicleInfo } from '../interfaces/IVehicleInfo';
import { HttpClient } from '@angular/common/http';
import { ICompany } from '../interfaces/ICompany';
import { IVehicle } from '../interfaces/IVehicle';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  public dataChanged = new Subject<IVehicleInfo[]>();

  constructor(private http: HttpClient) { }

  private companies: ICompany[];
  private vehicles: IVehicle[];
  private vehicleInfos: IVehicleInfo[];
  private completedRequest;
  private millisecondsStillOnline: number = 90000;

  getVehicles(): void {
    this.completedRequest = [false, false];
    this.requestGetCompanies().subscribe(
      data => {
        this.companies = data;

        if (this.completedRequest[1]){
          this.mapData();
        } else {
          this.completedRequest[0] = true;
        }
      }
    );

    this.requestGetVehicles().subscribe(
      data => {
        this.vehicles = data;

        if (this.completedRequest[0]){
          this.mapData();
        } else {
          this.completedRequest[1] = true;
        }
      }
    );
  }

  private getCompanyNameById(id: number): string{
    for (const company of this.companies){
      if (company.id === id){
        return company.name;
      }
    }
  }

  private mapData(){
    const newVehicleInfos: IVehicleInfo[] = [];
    for (const vehicle of this.vehicles){
      const timePassed = new Date(vehicle.lastCommunicated).getTime() - new Date().getTime();
      const online = timePassed < this.millisecondsStillOnline;
      newVehicleInfos.push({
        company: this.getCompanyNameById(vehicle.companyId),
        vin: vehicle.vin,
        regnumber: vehicle.registrationNumber,
        status: online ? 'online' : 'offline',
        lastCommunication: vehicle.lastCommunicated
      });
    }

    this.vehicleInfos = newVehicleInfos;

    this.dataChanged.next(this.vehicleInfos);
  }

  private requestGetCompanies(){
    return this.http.get<ICompany[]>('/api/companies');
  }

  private requestGetVehicles(){
    return this.http.get<IVehicle[]>('/api/vehicles');
  }
}
