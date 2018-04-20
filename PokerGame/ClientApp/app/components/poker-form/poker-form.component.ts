import { Component, OnInit } from '@angular/core';
import { Card } from './../../models/card';
import { CardService } from '../../services/card.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';

@Component({
    selector: 'app-poker-form',
    templateUrl: './poker-form.component.html',
    styleUrls: ['./poker-form.component.css'],
    providers: [CardService]
})
export class PokerFormComponent implements OnInit {
    cards: Card[];
    sortedCards: Card[];
    pokerForm: FormGroup;
    card1: String;
    card2: String;
    card3: String;
    card4: String;
    card5: String;

    controlPair: String = "No";
    controlThree: String = "No";
    controlLadder: String = "No";
    controlPocker: String = "No";
    controlColor: String = "No";

    constructor(private cardService: CardService,
                private router: Router,
                private route: ActivatedRoute) { }

    ngOnInit() {
        this.cardService.getCardsInHand().subscribe(cards => {
            this.cards = cards;            
            this.onFillCards();
            this.getSummary();
        });         

    }

    onNewGame() {
        this.cardService.shuffleCards().subscribe(cards => {
            this.cards = cards;
            this.onFillCards();
            this.getSummary();
        });    
    }

    onFillCards() {
        this.card1 = this.cards[0].imagePath;
        this.card2 = this.cards[1].imagePath;
        this.card3 = this.cards[2].imagePath;
        this.card4 = this.cards[3].imagePath;
        this.card5 = this.cards[4].imagePath;        
    }

    getSummary() {
        if (this.cards.length > 0) {
            this.sortedCards = this.cards.sort(this.compare);    
            //this.groupBy(this.sortedCards);

            //var groupedCardsByRank = this.groupBy(sortedCards, function (item:Card) { return [item.nRank]; });

            //var groupedCardsBySuit = this.groupBy(sortedCards, function (item:Card) { return [item.nSuit]; });

            //getPairsThreePocker(groupedCardsByRank);
            this.getLadder();
            //getColor(groupedCardsBySuit);
        }
    }

    groupBy(sortedCards:Card[])
    {        
        var group:[number,number][5];

        for (var i = 0; i < sortedCards.length; i++) {            
            console.log(sortedCards[i]);           
        }     
    }
   
    compare(a:Card, b:Card) {
        if (a.nRank < b.nRank)
            return -1;
        if (a.nRank > b.nRank)
            return 1;
        return 0;
    }

    getLadder() {
        var result = false;
        for (var i = this.sortedCards.length - 1; i >= 0; i--) {
            if (i > 0) {
                if (this.sortedCards[i].nRank - this.sortedCards[i - 1].nRank == 1) {
                    result = true;
                }
                else {
                    result = false;
                    break;
                }
            }
        }
        if (result) {
            this.controlLadder = "Yes";
        }
       
    }
}