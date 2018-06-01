import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PersonFormComponent } from './components/person-form/person-form.component';
import { PersonService } from './services/person.service';
import { AppErrorHandler } from './app.error-handler';
import { PeopleListComponent } from './components/people-list/people-list';
import { PersonPhotoComponent } from './components/person-photo/person-photo.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        PersonFormComponent,
        PeopleListComponent,
        PersonPhotoComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'people', pathMatch: 'full' },
            { path: 'people/new', component: PersonFormComponent },
            { path: 'people/:id', component: PersonPhotoComponent },
            { path: 'people', component: PeopleListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        PersonService
    ]
})
export class AppModuleShared {
}
