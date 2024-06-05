import adminStyle from "../../../styles/Admin/style.module.css";

export default function Create() {
  return (
    <>
      <div className="formCover bg-white shadow-md p-5 m-2 rounded-md">
        <form>
          <div className="formBody">
            <div className="row">
              <div className="col-span-2 ">
                <div className={adminStyle.inputGroup}>
                  <label>Title</label>
                  <input placeholder="Title" />
                </div>
              </div>

              <div className="grid col-span-2">
                <div className={adminStyle.inputGroup}>
                  <label>Test</label>
                  <input placeholder="inputbox" />
                </div>
              </div>
            </div>
          </div>
          <div className="btn-group ">
            <button type="button" className="btn btn-success">
              Save
            </button>
            <button type="button" className="btn btn-primary">
              Cancel
            </button>
          </div>
        </form>
      </div>
    </>
  );
}
