export default function showArrayStore() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div id='heading'></div>
    <div class='row'>
      <div id='byKey'></div>
    </div>
    <div class='row'>
      <div id='clear'></div>
    </div>
    <div class='row'>
      <div id='createQuery'></div>
    </div>
    <div class='row'>
      <div id='insert'></div>
    </div>
    <div class='row'>
      <div id='key'></div>
    </div>
    <div class='row'>
      <div id='keyOf'></div>
    </div>
    <div class='row'>
      <div id='load'></div>
    </div>
    <div class='row'>
      <div id='push'></div>
    </div>
    <div class='row'>
      <div id='remove'></div>
    </div>
    <div class='row'>
      <div id='totalCount'></div>
    </div>
    <div class='row'>
      <div id='update'></div>
    </div>`
  );

  $("#heading").dxButton({
    text: "Array Store",
    onClick: () => {
      console.log(store);
    },
  });

  var states = [
    { id: 1, state: "Alabama", capital: "Montgomery" },
    { id: 2, state: "Alaska", capital: "Juneau" },
    { id: 3, state: "Arizona", capital: "Phoenix" },
  ];

  var dataSource = new DevExpress.data.DataSource({
    store: {
      type: "array",
      key: "id",
      data: states,
    },
  });

  console.log("dataSource", dataSource);

  //ArrayStore is immutable, cannot change at runtime.
  var store = new DevExpress.data.ArrayStore({
    key: "id", // key must consists stateId
    data: states,
    onInserting: (values) => {
      console.log("*inserting..", "values", values);
    },
    onInserted: (values, key) => {
      console.log("*inserted..", "key", key, "values", values);
    },
    onLoaded: (result) => {
      console.log("*loaded..", "result", result);
    },
    onLoading: (loadOptions) => {
      console.log("*loading..", "loadOptions", loadOptions);
    },
    onModified: () => {
      console.log("*modified..");
    },
    onModifying: () => {
      console.log("*modifying..");
    },
    onPush: () => {
      console.log("*push");
    },
    onRemoving: (key) => {
      console.log("*removing..", "key", key);
    },
    onRemoved: (key) => {
      console.log("*removed..", "key", key);
    },
    onUpdated: (key, values) => {
      console.log("*updated..", "key", key, "values", values);
    },
    onUpdating: (key, values) => {
      console.log("*updating..", "key", key, "values", values);
    },
    errorHandler: (err) => {
      console.log("err", err);
    },
  });

  console.log("store", store);

  $("#byKey").dxButton({
    text: "By Key (1)",
    onClick: () => {
      store
        .byKey(1)
        .done((dataItem) => {
          console.log("done", "dataItem", dataItem);
        })
        .fail((err) => {
          console.log("fail", err);
        });
    },
  });

  // clears all data of the store
  $("#clear").dxButton({
    text: "Clear",
    onClick: () => {
      store.clear();
    },
  });

  $("#createQuery").dxButton({
    text: "createQuery",
    onClick: () => {
      var query = store.createQuery();
      console.log("Query", query);
    },
  });

  $("#insert").dxButton({
    text: "Insert 4 Gujarat Gandhinagar into store",
    onClick: () => {
      store
        .insert({
          id: 4,
          state: "Gujarat",
          capital: "Gandhinagar",
        })
        .done((dataObj, key) => {
          console.log(
            "**done | data inserted ",
            "dataObj",
            dataObj,
            "key",
            key
          );
        })
        .fail(() => {
          console.log("**fail | data insertion failed");
        });
    },
  });

  $("#key").dxButton({
    text: "Key",
    onClick: () => {
      var keyProps = store.key();
      console.log("keyProps", keyProps);
    },
  });

  // we have to provide full object
  // partial object ( object with missing fields) is not acceptable
  $("#keyOf").dxButton({
    text: "keyOf( Alaska)",
    onClick: () => {
      var key = store.keyOf({
        id: 2,
        state: "Alaska",
        capital: "Juneau",
      });
      console.log("key", key);
    },
  });

  $("#load").dxButton({
    text: "load",
    onClick: () => {
      store.load();
    },
  });

  $("#push").dxButton({
    text: "Push",
    onClick: () => {
      console.log("******** push = insert ********");
      store.push([
        {
          type: "insert",
          data: { id: 4, state: "Gujarat", capital: "Gandhinagar" },
          index: 4,
        },
      ]);
      console.log("******** push = update ********");
      store.push([
        {
          type: "update",
          data: { id: 4, state: "Gujarat", capital: "Surat" },
          key: 4,
        },
      ]);
      console.log("******** push = remove ********");
      store.push([
        {
          type: "remove",
          key: 4,
        },
      ]);
    },
  });

  $("#remove").dxButton({
    text: "Remove",
    onClick: () => {
      store.remove(3); // parameter => key
    },
  });

  $("#totalCount").dxButton({
    text: "Total",
    onClick: () => {
      store
        .totalCount()
        .done((count) => {
          console.log(count);
        })
        .fail((err) => {
          console.log(err);
        });
    },
  });

  $("#update").dxButton({
    text: "Upadte 1 Delhi New Delhi",
    onClick: () => {
      store.update(1, {
        state: "Delhi",
        capital: "New Delhi",
      });
    },
  });
}
