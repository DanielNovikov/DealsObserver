import {Component, OnInit} from '@angular/core';
import {DealsHttpService} from '../shared/services/deals-http.service';
import {DealDto} from '../shared/models/deal-dto';
import {TheMostPopularVehicleDto} from '../shared/models/the-most-popular-vehicle-dto';

@Component({
  selector: 'deals',
  templateUrl: './deals.component.html',
})
export class DealsComponent implements OnInit {
  deals: DealDto[] = [];
  theMostPopularVehicle: TheMostPopularVehicleDto = null;

  constructor(private http: DealsHttpService) {
  }

  ngOnInit(): void {
    this.http.getAll()
      .subscribe(deals => {
        this.deals = deals;

        if (this.deals) {
          this.http.getTheMostPopularVehicle()
            .subscribe(vehicle => {
              this.theMostPopularVehicle = vehicle;
            });
        }
      });
  }



}
