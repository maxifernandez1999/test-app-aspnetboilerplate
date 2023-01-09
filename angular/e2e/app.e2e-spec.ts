import { myTestProjectTemplatePage } from './app.po';

describe('myTestProject App', function() {
  let page: myTestProjectTemplatePage;

  beforeEach(() => {
    page = new myTestProjectTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
