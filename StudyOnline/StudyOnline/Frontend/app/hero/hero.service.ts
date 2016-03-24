import {Injectable} from 'angular2/core';
import {HEROES}     from './mock-heroes';

export interface IHeroService {
    getHeroes(): Promise(HEROES);
    getHero(id: number);
}

@Injectable()
export class HeroService implements IHeroService{
  public async getHeroes(): Promise(HEROES) {
    return HEROES;
  }

	public async getHero(id: number) {
    return Promise.resolve(HEROES).then(
      heroes => heroes.filter(hero => hero.id === id)[0]
    );
  }
}
