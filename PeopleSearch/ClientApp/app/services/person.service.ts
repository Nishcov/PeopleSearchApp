import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()

export class PersonService {

    constructor(private http: Http) { }

    getPeople() {
        return this.http.get('/api/people')
            .map(res => res.json());
    }

    getPerson() {
        return this.http.get('/api/people/{id}')
            .map(res => res.json());
    }

    create(person: any) {
        return this.http.post('/api/people', person)
            .map(res => res.json());
    }
}
