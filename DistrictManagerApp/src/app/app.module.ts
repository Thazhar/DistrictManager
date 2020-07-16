import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DistrictsComponent } from './districts/districts.component';
import { HttpErrorHandlerService } from './Services/http-error-handler.service';
import { DistrictDetailComponent } from './district-detail/district-detail.component';
import { AppRoutingModule } from './app-routing.module';
import { AddDataComponent } from './add-data/add-data.component';
import {FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    DistrictsComponent,
    DistrictDetailComponent,
    AddDataComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [HttpErrorHandlerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
