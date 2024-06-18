export interface NewsArticle {
    title: string,
    content: string,
    sourceUrl: string,
    imgUrl: string,
    tags: string[],
    coords: { lat: number, lon: number },
    publishedAt: string
}