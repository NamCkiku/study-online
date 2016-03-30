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

export function makePaginator(limitPerPage: number, currentPageNum: number, totalCount: number): Paginator {
    if (typeof totalCount === "undefined" || totalCount === null) {
        return null;
    }
    let lastPageNum = Math.floor((totalCount - 1) / limitPerPage) + 1;
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
