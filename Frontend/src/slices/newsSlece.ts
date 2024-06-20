import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {NewsArticle} from "../../DTO/NewsArticle";

export interface newsState {
    activeNewsArticle: NewsArticle | null;
    newsArticles: NewsArticle[]
}

const initialState: newsState = {
    activeNewsArticle: null,
    newsArticles: []
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
        }
    }
})

export const {setActiveNewsArticle, setNewsArticles} = newsSlice.actions
export default newsSlice.reducer