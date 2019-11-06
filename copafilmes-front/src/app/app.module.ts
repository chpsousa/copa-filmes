import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import {
  MatToolbarModule,
  MatIconModule,
  MatCardModule,
  MatCheckboxModule,
  MatSnackBarModule,
  MatButtonModule,
  MatListModule
} from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';


import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { LayoutHeaderComponent } from './shared/layout/layout-header/layout-header.component';
import { LayoutMainComponent } from './shared/layout/layout-main/layout-main.component';
import { LayoutFooterComponent } from './shared/layout/layout-footer/layout-footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MoviesSelectionComponent } from './movies/movies-selection/movies-selection.component';
import { MoviesResultComponent } from './movies/movies-result/movies-result.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutHeaderComponent,
    LayoutMainComponent,
    LayoutFooterComponent,
    MoviesSelectionComponent,
    MoviesResultComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FlexLayoutModule,
    MatButtonModule,
    MatToolbarModule,
    MatSnackBarModule,
    MatIconModule,
    MatListModule,
    MatCheckboxModule,
    MatCardModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
