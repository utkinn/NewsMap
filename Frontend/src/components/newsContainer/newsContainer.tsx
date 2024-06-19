import React, { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import {ReactComponent as CloseSvg} from '../../icons/close.svg';
import { setActiveNewsArticle } from '../../slices/newsSlece';
import './newsContainer.scss';

export const NewsContainer = () => {
    const ActiveArticle = useAppSelector(state=>state.news.activeNewsArticle);
    const dispatch = useAppDispatch();
    return (
        <React.Fragment>
        {ActiveArticle ? 
        <div className='news-container'>
            <h2>{ActiveArticle.title}</h2>
            <img src={ActiveArticle.imgUrl} alt="Упс... Картинка не загрузилась"/>
            <div>{ActiveArticle.publishedAt.split("T")[0] + " · "} <a href={ActiveArticle.sourceUrl}>{new URL(ActiveArticle.sourceUrl).hostname}</a></div>
            <div className='news-text'>{ActiveArticle.content}</div>
            <CloseSvg className='close-icon' onClick={()=> dispatch(setActiveNewsArticle(null))}/>
        </div>
        : null}
        </React.Fragment>
    );
};