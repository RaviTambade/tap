import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DetailsComponent } from './details/details.component';
import { InsertShipperComponent } from './insert/insert.component';
import { UpdateComponent } from './update/update.component';
import { GetShipperComponent } from './getshipper/getshipper.component';
import { RouterModule, Routes } from '@angular/router';
import { ShipperroutingComponent} from './shipperrouting/shipperrouting.component';


const routes: Routes = [
  {path:'list',component:ListComponent},
  {path:'detailsshipper',component:DetailsComponent},
  {path:'insertshipper',component:InsertShipperComponent},
  {path:'updateshipper',component:UpdateComponent},
]






@NgModule({
  declarations: [
        ListComponent,
        DetailsComponent,
        UpdateComponent,
        InsertShipperComponent,
        GetShipperComponent,
        ShipperroutingComponent,
   
      
  ],     
  exports:[
    ListComponent,
    DetailsComponent,
    UpdateComponent,
    InsertShipperComponent,
    GetShipperComponent,
    ShipperroutingComponent
  ],
  imports:[
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild(routes)
  
  ]
})
export class ShipperModule { }
