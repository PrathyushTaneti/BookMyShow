import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AppService } from '../Services';

@Component({
  selector: 'app-view-movie-detail',
  templateUrl: './view-movie-detail.component.html'
})
export class ViewMovieDetailComponent implements OnInit {
  public id: number = 0;
  public movieDetail!: any;
  
  constructor(private router: Router, private activatedRoute: ActivatedRoute,private service:AppService ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((parameter) => {
      this.id = parameter.get('id') as any as number;
      this.movieDetail = this.service.getMovieDetailById(this.id);
      // this.movieDetail = this.service.getAllMovieDetails();
      window.console.log("From View",this.movieDetail);
    })
  }
}
