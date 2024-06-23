import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { NewsArticle } from "../../DTO/NewsArticle";

export interface newsState {
    activeNewsArticle: NewsArticle | null;
    newsArticles: NewsArticle[];
    filter: {
        news: boolean;
        attraction: boolean;
        culture : boolean;
        jkx: boolean;
    }
}

const initialState: newsState = {
    activeNewsArticle: null,
    newsArticles: [
        {
            "title": "Через два дня в Магнитогорске официально откроют обновлённый Северный пляж",
            "content": "Некогда дикий пляж рядом с парком Ветеранов Магнитки не узнать: под ногами приятно похрустывает чистая галька, на территории расставлены красивые лежаки, в воздухе – явный запах нового дерева.",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/vip-news/cherez-dva-dnya-v-magnitogorske-ofitsialno-otkroyut-obnovlennyy-severnyy-plyazh",
            "imageUrl": "https://img.verstov.info/rs:fill/w:660/q:80/plain/https://www.verstov.info/wmark/upload/iblock/63c/6nvasoka3r6hk4igbq654iufk52c5cmr/IMG_5486.jpg",
            "tags": [
                "Городская среда"
            ],
            "coordinates": {
                "lat": 53.43152778,
                "long": 59.00347222
            }
        },
        {
            "title": "Дорожные работы по нацпроекту в Магнитогорске выходят на финишную прямую",
            "content": "Всего за дорожный сезон в Магнитогорске в рамках нацпроекта «Безопасные качественные дороги» обновят более пяти километров дорог.Ещё несколько лет назад муниципалитеты Челябинской области и мечтать не могли о приведении в нормативное состояние дорог. В сельской местности ситуация была ещё более плачевной, чем в малых и больших городах: на ямы и ухабы в местной казне средств не было, а из областного бюджета деньги на эти цели не выделялись.",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/society/dorozhnye-raboty-po-natsproektu-v-magnitogorske-vykhodyat-na-finishnuyu-pryamuyu",
            "imageUrl": "https://img.verstov.info/rs:fill/w:660/q:80/plain/https://www.verstov.info/wmark/upload/iblock/b23/sjdcg30amboxl5jxtwat6p97akoh218z/01.jpg",
            "tags": [
                "Городская среда",
                "Ремонтные работы"
            ],
            "coordinates": {
                "lat": 53.368796972295904,
                "long": 58.9901959984431
            }
        },
        {
            "title": "В Магнитогорске отметили Сабантуй, а главе города подарили лошадь",
            "content": "Традиционным местом проведения праздника стала южная часть парка У Вечного огня, примыкающая к Центральной городской ярмарке. В этом году организаторам праздника повезло с погодой. Сотни горожан пришли в субботнее жаркое утро в парк, чтобы стать гостями торжества, которое называют праздником плуга. Сабантуй испокон веков проводят в честь окончания весенних полевых работ. К слову, в Магнитогорске праздник с размахом проводят уже 26-й год подряд.",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/dosug/v-magnitogorske-otmetili-sabantuy-a-glave-goroda-podarili-loshad",
            "imageUrl": "https://img.verstov.info/rs:fill/w:1920/q:80/plain/https://www.verstov.info/wmark/upload/iblock/1df/ukppfn570lgjhvcjmlw8sbcavrdzv1im/IMG_6902.jpg",
            "tags": [
                "Праздники",
                "Развлечения"
            ],
            "coordinates": {
                "lat": 53.401636003346134,
                "long": 58.99230339693254
            },
            "drawData": "[[[53.40259076075718,58.99093088925549],[53.402769859841655,58.9928191643968],[53.40256517511211,58.993537996433915],[53.40292976910147,58.99394032779797],[53.402865805469666,58.99454650705315],[53.40156732295459,58.994514320544035],[53.40173363327265,58.99344143690654],[53.401273080030215,58.991499517522676],[53.40229012845623,58.99029788784868]], []]"
        },
        {
            "title": "Объединяющий сезон – в Магнитогорске наградили победителей юбилейной игры-викторины",
            "content": "Инфа",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/dosug/obedinyayushchiy-sezon-v-magnitogorske-nagradili-pobediteley-yubileynoy-igry-viktoriny",
            "imageUrl": "",
            "tags": [
                "Развлечения"
            ],
            "coordinates": {
                "lat": 53.40721895088664,
                "long": 58.9823288793991
            }
        },
        {
            "title": "В Магнитогорске установили личность самокатчика, который сбил двухлетнего ребенка",
            "content": "Инфа",
            "publishedAt": "2024-06-18T16:17:17.208Z",
            "sourceUrl": "https://www.verstov.info/news/criminal/v-magnitogorske-ustanovili-lichnost-samokatchika-kotoryy-sbil-dvukhletnego-rebenka",
            "imageUrl": "",
            "tags": [
                "Проишествия",
                "ДТП"
            ],
            "coordinates": {
                "lat": 53.41191153558964,
                "long": 58.98472496324667
            }
        }
    ],
    filter: {
        news: true,
        attraction: true,
        culture: true,
        jkx: true
    }
};

export const newsSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        setActiveNewsArticle: (state, action: PayloadAction<NewsArticle | null>) => {
            state.activeNewsArticle = action.payload
        },

        setNewsArticles: (state, action: PayloadAction<NewsArticle[]>) => {
            state.newsArticles = action.payload
        },

        setFilter: (state, action: PayloadAction<{
            news: boolean;
            attraction: boolean;
            culture: boolean;
            jkx: boolean;
        }>) => {
            state.filter = action.payload
        }
    }
})

export const { setActiveNewsArticle, setNewsArticles, setFilter} = newsSlice.actions
export default newsSlice.reducer