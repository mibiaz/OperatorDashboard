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
  masonryItems = [
      {title: 'item 1'},
      {title: 'item 2'},
      {title: 'item 3'},
      {title: 'item 4'}
  ];

  title = 'Operator Dashboard';

  options: any;
  updateOptions: any;

  private value: number;
  private timer: any;

  constructor() {}

  ngOnInit() {

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
}
