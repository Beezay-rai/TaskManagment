import ChevronLeftIcon from "@mui/icons-material/ChevronLeft";
import ChevronRightIcon from "@mui/icons-material/ChevronRight";

export const Pagination = ({
  totalItems,
  itemsPerPage,
  paginate,
  currentPage,
}) => {
  const pageNumbers = [];
  for (let i = 1; i <= Math.ceil(totalItems / itemsPerPage); i++) {
    pageNumbers.push(i);
  }

  return (
    <nav className="mt-5">
      <ul className="pagination">
        <li
          className="page-item"
          onClick={() =>
            pageNumbers.includes(currentPage - 1) && paginate(currentPage - 1)
          }
        >
          <ChevronLeftIcon />
        </li>
        {pageNumbers.map((number) => (
          <li
            key={number}
            onClick={() => paginate(number)}
            className={`page-item ${currentPage === number ? "active" : ""}`}
          >
            <span>{number}</span>
          </li>
        ))}

        <li
          className="page-item"
          onClick={() =>
            pageNumbers.includes(currentPage + 1) && paginate(currentPage + 1)  `1345 `
          }
        >
          <ChevronRightIcon />
        </li>
      </ul>
    </nav>
  );
};

export default Pagination;
