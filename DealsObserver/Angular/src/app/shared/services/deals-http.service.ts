import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {DealDto} from '../models/deal-dto';
import {TheMostPopularVehicleDto} from '../models/the-most-popular-vehicle-dto';

@Injectable({
  providedIn: 'root'
})
export class DealsHttpService {
  private getDealsEndpoint = 'api/Deals/GetAll';
  private getTheMostPopularVehicleEndpoint = 'api/Deals/GetTheMostPopularVehicle';
  private uploadCsvEndpoint = 'api/Deals/UploadCsv';

  constructor(private http: HttpClient) {
  }

  public getAll(): Observable<DealDto[]> {
    return this.http.get<DealDto[]>(this.getDealsEndpoint);
  }

  public getTheMostPopularVehicle(): Observable<TheMostPopularVehicleDto> {
    return this.http.get<TheMostPopularVehicleDto>(this.getTheMostPopularVehicleEndpoint);
  }

  public uploadCsv(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('csv', file);

    return this.http.post(this.uploadCsvEndpoint, formData);
  }
}
