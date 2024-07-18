import adminStyle from "../../styles/Admin/style.module.css";

export const DataTable = ({ items, headers, search, action, pagination }) => {
  return (
    <>
      <div className="tools flex justify-between">
        <div className="pagination">
          <select className="select border-solid border-2 outline-2 outline-gray-400 active:border-2 active:outline-2 active:outline-white">
            <option>10</option>
            <option>20</option>
            <option>50</option>
    
          </select>
          entries per page
        </div>

        <div className="search">
          Search : <input className="" type="text"></input> 
        </div>
      </div>
      <table className={adminStyle.table}>
        <thead>
          {headers ? (
            <>
              <tr>
                {headers.map((data) => {
                  return <th>{data}</th>;
                })}
              </tr>
            </>
          ) : (
            <></>
          )}
        </thead>

        {/* <tbody>
          {currentItems.length > 0 ? (
            currentItems.map((data, index) => {
              return (
                <tr key={index}>
                  <td width="10%">{index + 1}</td>
                  <td>{data.id}</td>
                  <td>{data.name}</td>

                  <td>
                    <a href="TaskCategory/Edit?id=1" title="Edit">
                      <BorderColorOutlinedIcon className="size-5 text-green-400" />
                    </a>
                    <a href="Detail" title="Detail">
                      <VisibilityOutlinedIcon className="size-5 text-blue-400" />
                    </a>
                    <a href="Delete" title="Delete">
                      <DeleteOutlineOutlinedIcon className="size-5 text-red-400" />
                    </a>
                  </td>
                </tr>
              );
            })
          ) : appState.isLoading ? (
            <tr>
              <td colSpan="5">Loading.... </td>
            </tr>
          ) : (
            <tr>
              <td colSpan="5">No Data</td>
            </tr>
          )}
        </tbody> */}
      </table>
      {/* <Pagination
        totalItems={taskList.length}
        itemsPerPage={itemPerPage}
        paginate={paginate}
      /> */}
    </>
  );
};
