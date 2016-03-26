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
