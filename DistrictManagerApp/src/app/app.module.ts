import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DistrictsComponent } from './districts/districts.component';
import { HttpErrorHandlerService } from './Services/http-error-handler.service';
import { DistrictDetailComponent } from './district-detail/district-detail.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    DistrictsComponent,
    DistrictDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [HttpErrorHandlerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
