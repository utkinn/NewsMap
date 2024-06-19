import React, { useState } from 'react';
import './searchNewsPanel.scss';
import {ReactComponent as NewsIcon} from '../../icons/news.svg';
import {ReactComponent as HideIcon} from '../../icons/hide.svg';
import { useAppSelector } from '../../app/hooks';
import { LowTextNewsArticle } from './lowTextNewsArticle';
import { setActiveNewsArticle } from '../../slices/newsSlece';
export const SearchNewsPanel = () => {
    const news= useAppSelector(state => state.news.newsArticles);
    const [hide, setHide] = useState(false);
    const [filter, setFilter] = useState('');


    return(
        <div className='search-news-container'>
            <div className='search-news-header'>
                <NewsIcon/>
                <HideIcon className='clickable' onClick={()=> setHide(!hide)}/>
            </div>
            {hide ? null : 
            <React.Fragment>
                <input className='search-news-input' placeholder='Поиск новостей по заголовку' value={filter} onChange={(e)=> setFilter(e.target.value)}/>
                <div className='search-news-blocks'>
                {news.map((elem, index) => (
                    elem.title.toLocaleLowerCase().includes(filter.toLocaleLowerCase()) ? <LowTextNewsArticle key={index} news={elem} 
                    /> : null
                ))}
                </div>
            </React.Fragment>}
        </div>
    )
}