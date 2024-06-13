type Props = {
  params: {pageNum: string};
  searchParams: {sort: string, order: string}
};

export default async function Page({params, searchParams}: Props) {
    return (
        <div className="mx-auto max-w-7xl px-6 sm:px-12">
            <p>main products page</p>
            <p>pageNum = {params.pageNum}</p>
            <p>sort by {searchParams.sort}</p>
            <p>order by {searchParams.order}</p>
            <p>SORT SELECTOR</p>
            <p>MAIN PRODUCT DASHBOARD</p>
            <p>PAGINATOR</p>
        </div>
    );
}