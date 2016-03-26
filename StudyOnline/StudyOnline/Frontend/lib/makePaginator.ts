/// <reference path="../../typings/curama.d.ts"/>

export interface Paginator {
    prev?: string;
    prevPageNum?: number;
    next?: string;
    nextPageNum?: number;
    lastPageNum?: number;
    pageRange?: PageRange[];
    currentPageNum?: number;  // current page number
    startIndex: number;
    endIndex: number;
    totalCount: number;
    hasPrevious: boolean;
    hasNext: boolean;
}

export interface PageRange {
        pageNum: number;
}

/**
 * ページネーションに必要な情報を作ります
 * @param  {number}    limitPerPage   1ページの表示件数
 * @param  {number}    currentPageNum 現在のページナンバー
 * @param  {number}    totalCount     全件数
 * @return {Paginator}                [description]
 */
export function makePaginator(limitPerPage: number, currentPageNum: number, totalCount: number): Paginator {
    if (typeof totalCount === "undefined" || totalCount === null) {
        return null;
    }
    let lastPageNum = Math.floor((totalCount - 1) / limitPerPage) + 1; // currentやnextと同じ値があり得る
    let pageRange = range(1, lastPageNum);
    // for (let pageNum: number = 1; pageNum <= lastPageNum; pageNum++) {
    //     pageRange.push({pageNum: pageNum});
    // }

    let endIndex = currentPageNum * limitPerPage;
    if (totalCount < limitPerPage) {
        endIndex = totalCount;
    }

    return {
        prevPageNum: (currentPageNum !== 1) ? currentPageNum - 1 : null,
        currentPageNum: currentPageNum,
        nextPageNum: (currentPageNum * limitPerPage < totalCount) ? currentPageNum + 1 : null,
        lastPageNum: lastPageNum,
        pageRange: pageRange,
        startIndex: (currentPageNum - 1) * limitPerPage + 1,
        endIndex: endIndex,
        totalCount: totalCount,
        hasPrevious: Number(currentPageNum) !== 1,
        hasNext: Number(currentPageNum) !== lastPageNum
    };
}

/**
 * 必要なpageRangeを返します
 * @param  {PageRange[]} pageRange      makePaginatorの返り値のpageRange
 * @param  {number}      currentPageNum 現在のページナンバー
 * @param  {number}      displayCount   paginatorに表示するページ数
 * @return {PageRange[]}                [description]
 */
export function cutPageRange(pageRange: PageRange[], currentPageNum: number, displayCount: number): PageRange[] {
    currentPageNum = Number(currentPageNum);
    if (displayCount > currentPageNum) {
        return range(1, displayCount);
    }
    if ((currentPageNum + displayCount) >= pageRange.length) {
        return range((pageRange.length - displayCount + 1), pageRange.length);
    }
    let returnArray = [currentPageNum];
    let tmp = 1;
    while (returnArray.length < displayCount) {
        returnArray.push(currentPageNum + tmp);
        returnArray.push(currentPageNum - tmp);
        tmp++;
    }

    // 数値ソート http://qiita.com/PianoScoreJP/items/f0ff7345229871039672
    returnArray.sort(function(a: number, b: number): number {
        if ( a < b ) { return -1; }
        if ( a > b ) { return 1; }
        return 0;
    });

    let returnPageRange = [];
    for (let i of returnArray) {
        returnPageRange.push({ pageNum: i });
    }

    return returnPageRange;
}

function range(start: number, end: number): PageRange[] {
    let pageRange = [];
    if (start > end) {
        pageRange.push({pageNum: start});
        return pageRange;
    }

    for (let pageNum: number = start; pageNum <= end; pageNum++) {
        pageRange.push({pageNum: pageNum});
    }
    return pageRange;
}
