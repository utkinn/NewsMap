export interface NewsArticle {
    title: string,
    content: string,
    sourceUrl: string,
    imageUrl: string,
    tags: string[],
    coordinates: { lat: number, long: number },
    publishedAt: string
}