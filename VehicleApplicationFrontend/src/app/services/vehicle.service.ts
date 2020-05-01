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

  private companies;
  private vehicles: IVehicle[];
  private vehicleInfos: IVehicleInfo[];
  private completedRequest;

  getVehicles(): void {
    this.completedRequest = [false, false];
    this.requestGetCompanies().subscribe(
      data => {
        const mappedCompanies: { [id: number]: string} = {};

        for (const company of data){
          mappedCompanies[company.Id] = company.Name;
        }

        this.companies = mappedCompanies;

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

  private mapData(){
    const newVehicleInfos: IVehicleInfo[] = [];
    for (const vehicle of this.vehicles){
      newVehicleInfos.push({
        company: this.companies[vehicle.CompanyId],
        vin: vehicle.Vin,
        regnumber: vehicle.RegistrationNumber,
        status: 'online',
        lastCommunication: vehicle.LastCommunicated
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

const tempData: IVehicleInfo[] = [
  { company: 'myCompany', vin: '12345', regnumber: '23456', status: 'offline', lastCommunication: new Date() },
  { company: 'myOtherCompany', vin: '56789', regnumber: '78945', status: 'online', lastCommunication: new Date() },
];
