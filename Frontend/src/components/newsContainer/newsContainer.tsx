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
            <img src={""} alt="Упс... Картинка не загрузилась"/>
            <div>{ActiveArticle.publishedAt.split("T")[0] + " · " + ActiveArticle.sourceUrl}</div>
            <div>{ActiveArticle.content}</div>
            <CloseSvg className='close-icon' onClick={()=> dispatch(setActiveNewsArticle(null))}/>
        </div>
        : null}
        </React.Fragment>
    );
};