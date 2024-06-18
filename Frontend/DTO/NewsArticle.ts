export interface NewsArticle{
    title: string,
    content: string,
    sourceUrl: string,
    tags: string[],
    coords: {lat:number, lon:number},
    publishedAt: string
}