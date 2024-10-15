import { useState } from "react";
import adminStyle from "../../styles/Admin/style.module.css";
import Pagination from "./pagination";

export default function DataTable({
  columns,
  data,
  loading = false,
  additionalData,
  addtionalHeading,
}) {
  const paginate = (currentPage) => setCurrentPage(currentPage);

  const [currentPage, setCurrentPage] = useState(1);
  const [itemPerPage, setItemPerPage] = useState(5);
  const paginated =data.slice((currentPage-1)*itemPerPage,currentPage*itemPerPage )
  return (
    <div>
      <div className="toolBox flex justify-between mb-4 flex-wrap gap-4">
        <div className="filter">
          <label className="label font-medium">Entries Per Page : </label>
          <select
            className="border outline-none"
            onChange={(e) => setItemPerPage(e.target.value)}
          >
            <option value="5">5</option>
            <option value="10">10</option>
            <option value="15">15</option>
          </select>
        </div>
        <div className="SearchBar">
          <label className="label font-medium">Search : </label>
          <input className="border outline-blue-400"></input>
        </div>
      </div>

      <table className={adminStyle.adminDataTable}>
        <thead>
          <tr>
            {columns.map((column) => (
              <th key={column.accessor}>{column.header}</th>
            ))}

            {addtionalHeading && addtionalHeading()}
          </tr>
        </thead>
        <tbody>
          {paginated.length > 0 ? (
            paginated.map((row, index) => (
              <tr key={index}>
                {columns.map((column) => (
                  <td key={column.accessor}>{row[column.accessor]}</td>
                ))}
                {additionalData && additionalData(index, row)}
              </tr>
            ))
          ) : loading ? (
            <tr>
              <td
                colSpan={columns.length + (additionalData ? 1 : 0)}
                className="flex justify-center gap-2"
              >
                <PuffLoader color="#00ffff" size={30} />
                Loading....{" "}
              </td>
            </tr>
          ) : (
            <tr>
              <td
                colSpan={columns.length + (additionalData ? 1 : 0)}
                style={{ textAlign: "center" }}
              >
                No Data
              </td>
            </tr>
          )}
        </tbody>
      </table>
      <Pagination
        totalItems={data.length}
        itemsPerPage={itemPerPage}
        paginate={paginate}
        currentPage={currentPage}
      />
    </div>
  );
}
