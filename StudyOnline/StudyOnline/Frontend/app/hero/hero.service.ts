<<<<<<< HEAD
//import {Injectable} from 'angular2/core';
//import {HEROES}     from './mock-heroes';

//export interface IHeroService {
//    getHeroes(): Promise(HEROES);
//    getHero(id: number);
//}

//@Injectable()
//export class HeroService implements IHeroService{
//  public async getHeroes(): Promise(HEROES) {
//    return HEROES;
//  }

//	public async getHero(id: number) {
//    return Promise.resolve(HEROES).then(
//      heroes => heroes.filter(hero => hero.id === id)[0]
//    );
//  }
//}
=======
import {Injectable} from 'angular2/core';

export interface IHeroService {
    getHeroes(): Promise<string>;
    getHero(id: number);
}

@Injectable()
export class HeroService implements IHeroService {
    public async getHeroes(): Promise<string> {
      return "";
    }

    public async getHero(id: number) {
      return 1;
    }
}
>>>>>>> 26078f3746919c24efd62f85f67d276596d1a147
