import React from "react";
import { NewsArticle } from "../../../DTO/NewsArticle";
import { useAppDispatch, useAppSelector } from "../../app/hooks";
import { setActiveNewsArticle } from "../../slices/newsSlece";

export const LowTextNewsArticle = ({news}: {news: NewsArticle}) => {
    const dispatch = useAppDispatch();
    const ActiveArticle = useAppSelector(state=>state.news.activeNewsArticle);
    return (
        <div className={(ActiveArticle?.title === news.title ? "active" : "") + " low-text-news-container"} onClick={()=> dispatch(setActiveNewsArticle(news))}>
            <div className="news-content">
                <h3>{news.title}</h3>
                <div>{news.publishedAt.split("T")[0] + " · "} <a href={news.sourceUrl}>{new URL(news.sourceUrl).hostname}</a></div>
                <div>{news.content}</div>
            </div>
            <img alt="Упс... Картинка не загрузилась" src={news.imgUrl}></img>
        </div>
    )
}