import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { movieDetail } from '../Models';
import { AppService } from '../Services';

@Component({
  selector: 'app-view-movie-detail',
  templateUrl: './view-movie-detail.component.html'
})
export class ViewMovieDetailComponent implements OnInit {
  public id: number = 0;
  public movieDetail!: movieDetail;
  public isMovieDetailPresent: boolean = false;
  
  constructor(private router: Router, private activatedRoute: ActivatedRoute,private service:AppService ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((parameter) => {
      this.id = parameter.get('id') as any as number;
      this.service.getMovieDetailById(this.id).subscribe(data => {
        this.movieDetail = data;
        window.console.log(this.movieDetail);  
        if (this.movieDetail != null) {
          this.isMovieDetailPresent = true;
        }
      })
    })
  }
}
