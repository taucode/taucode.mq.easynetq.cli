(defblock :name get-subscriber-message-type :is-top t
	(worker
		:worker-name get-subscriber-message-type
		:verb "type"
		:description "Gets message type description by name or its part."
		:usage-samples (
			"sub type Foo.MyMessage"
			"sub type MyMes"
			"sub type 'MyMes'"))


	(some-text
		:classes term string
		:action argument
		:alias type-name
		:description "Type name, or part of type name."
		:doc-subst "type name")

	(end)
)
