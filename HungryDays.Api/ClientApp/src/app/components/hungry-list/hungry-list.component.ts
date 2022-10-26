import { Component, OnInit } from '@angular/core';
import { HungryDay } from 'src/app/models/hungryDay';
import { HungryService } from 'src/app/services/hungry.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hungry-list',
  templateUrl: './hungry-list.component.html',
  styleUrls: ['./hungry-list.component.css']
})
export class HungryListComponent implements OnInit {

  hungryDay = <HungryDay>{};
  hungryDayId : number;

  constructor(private hungryService: HungryService, private route: ActivatedRoute) { 
    this.hungryDayId = 1;
  }

  ngOnInit(): void {
    
    this.route.params.subscribe((params) => {
      this.hungryDayId = params["id"];
    this.getHungryDay(this.hungryDayId);
    });


    this.route.params.subscribe(routeParams => {
    });
  }

  

  getHungryDay(id:number): void {
    this.hungryService.getHungryDay(id)
    .subscribe(hungry => this.hungryDay = hungry);
  }

}
