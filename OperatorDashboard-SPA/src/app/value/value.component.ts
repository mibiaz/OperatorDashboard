import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;
declare const require: any;

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  title = 'Operator Dashboard';

  options: any;
  values: any;
  updateOptions: any;

  private value: number;
  private timer: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
      this.getValues();

      $(document).ready(function() {
          const $grid = $('.grid').masonry({
              columnWidth: 120,
              itemSelector: '.grid-item'
          });

          $grid.on( 'click', '.grid-item-content', function( event ) {
              $( event.currentTarget ).parent('.grid-item').toggleClass('is-expanded');
              $grid.masonry();
          });

          const a = 50;
          if (a < 60) {
              $('#op1').fadeOut(1000, function() {
                  $('#op1').css('background-color', '#FF0000').fadeIn(1000);
              });
          }
      });
  }

  getValues() {
      this.http.get('http://localhost:5000/api/values').subscribe(response => {
          this.values = response;
      }, error => {
          console.log(error);
      });
  }
}
