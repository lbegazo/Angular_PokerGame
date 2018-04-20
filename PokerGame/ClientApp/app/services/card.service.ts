import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';


@Injectable()
export class CardService {

  constructor(private http:Http) { }

    getCardsInHand() {
        return this.http.get('/api/cards')
            .map(res => res.json());
    }

    shuffleCards() {
        return this.http.get('/api/shuffleCards')
            .map(res => res.json());
    }
}
