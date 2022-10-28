import { Component, OnInit } from '@angular/core';
import { HungryDay } from 'src/app/models/hungryDay';
import { HungryService } from 'src/app/services/hungry.service';
import { ActivatedRoute } from '@angular/router';
import { HungryItem } from 'src/app/models/hungryItem';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-hungry-list',
  templateUrl: './hungry-list.component.html',
  styleUrls: ['./hungry-list.component.css']
})
export class HungryListComponent implements OnInit {

  hungryDay = <HungryDay>{};
  hungryDayId : number;

  createItemForm = new FormGroup({
    name: new FormControl(''),
    quantity: new FormControl(0),
    store: new FormControl(''),
    bought: new FormControl(false)
  });

  updateHungryDayForm = new FormGroup({
    diner: new FormControl('', Validators.required)
  });

  constructor(private hungryService: HungryService, private route: ActivatedRoute, private formBuilder: FormBuilder) { 
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
    .subscribe({
      next: (data) => {
        this.hungryDay = data;
        console.log(data);
      },
      error: (e) => console.error(e)
    });
    //.subscribe(hungry => this.hungryDay = hungry);
  }

  resetHungryDay(id:number):void {
    this.hungryService.resetHungryDay(id)
    .subscribe({
      next: (res) => {
        console.log(res);
        this.getHungryDay(id);
      },
      error: (e) => console.error(e)
    });
  }

  updateHungryDay(id:number, data:HungryDay):void {
    this.hungryService.updateHungryDay(id, data)
    .subscribe({
      next: (res) => {
        console.log(res);
        this.getHungryDay(id);
      },
      error: (e) => console.error(e)
    });
  }

  update() : void{
    this.hungryDay.diner = this.updateHungryDayForm.value.diner ?? "error";
    this.updateHungryDay(this.hungryDayId,this.hungryDay);
  }

  //move to createItemFormComponent
  createItem() : void{

    var hungryItemToAdd = <HungryItem>{
      name: this.createItemForm.value.name,
      store: this.createItemForm.value.store,
      quantity: this.createItemForm.value.quantity,
      bought: this.createItemForm.value.bought
    };
    
  }

}
