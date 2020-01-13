import { Injectable } from '@angular/core';
import { Title, Meta, MetaDefinition } from '@angular/platform-browser';
import { StringUtils } from 'src/app/common/data-type-utils/string-utils';

@Injectable({
  providedIn: 'root'
})
export class SeoService {
  private titleService: Title;
  private headMetas: Meta;

  public constructor(titleService: Title, meta: Meta) {
    this.titleService = titleService;
    this.headMetas = meta;
    this.setTitle('');
  }

  public setSeoData(seoModel: SeoModel) {
    this.setTitle(seoModel.title);
    this.setMetaRobots(seoModel.robots);
    this.setMetaDescription(seoModel.description);
    this.setMetaKeywords(seoModel.keywords);
    this.setTwitter(seoModel.twitterCard);
  }

  private setTitle(newTitle: string) {
    if (StringUtils.isNullOrEmpty(newTitle)) { newTitle = 'Sem titulo'; }
    this.titleService.setTitle(newTitle + ' - Gol');
  }

  private setMetaDescription(description: string) {
    this.CreateOrRemoveMetaElement({
      name: 'description',
      content: description
    });
  }

  private setMetaKeywords(keywords: string) {
    this.CreateOrRemoveMetaElement({
      name: 'keywords',
      content: keywords
    });
  }

  private setMetaRobots(robots: string) {
    this.CreateOrRemoveMetaElement({
      name: 'robots',
      content: robots,
    });
  }

  private setTwitter(twitter: string) {
    this.CreateOrRemoveMetaElement({
      name: 'twitter:card',
      content: twitter
    });
  }

  private CreateOrRemoveMetaElement(el: MetaDefinition): void {
    this.headMetas.removeTag('name="' + el.name + '"');
    this.headMetas.removeTag('property="' + el.property + '"');
    if (!StringUtils.isNullOrEmpty(el.content)) {
      this.headMetas.addTag(el, false);
    }
  }
}


export class SeoModel {
  public title = '';
  public robots = '';
  public description = '';
  public keywords = '';
  public twitterCard = '';
}
